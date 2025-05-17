using System.Diagnostics;
using Engine;

namespace HungryPeople
{
    public partial class HungryPeople : Form
    {
        private Player _player;
        private CounterTop _counterTop;
        private CounterTop _counterTop2;
        private Appliance _stove;
        private Pantry _steakFridge;
        private CutleryStorage _plateRack;
        private SanitationStation _sink;
        private Order _order;
        private Table _table;
        private Customer? _customer;

        // Timer
        private readonly System.Windows.Forms.Timer _timer = new();
        private readonly System.Windows.Forms.Timer _EatingTimer = new();
        private readonly System.Windows.Forms.Timer _holdTimer = new();

        //private int _CleaningCounter = 0;

        public HungryPeople()
        {
            InitializeComponent();

            _player = new Player();
            _counterTop = new CounterTop();
            _counterTop2 = new CounterTop();

            _stove = World.GetApplianceByID(World.APPLIANCE_ID_STOVE);
            _steakFridge = World.GetPantryByID(World.PANTRY_ID_STEAK_FRIDGE);
            _plateRack = World.GetCutleryStorageByID(World.STORAGE_ID_PLATE_RACK);
            _sink = World.GetSanitationStationByID(World.SANITATION_STATION_ID_SINK);
            _table = new Table();

            _customer = _table.GenerateCustomer();
            _customer.IsSeated = true;

            Debug.WriteLine(_customer == null);

            UpdateOrderUI();

            // Data binding properties to their respectice labels
            lblHandItem.DataBindings.Add("Text", _player, nameof(_player.HandItemName));
            lblCounterTop.DataBindings.Add("Text", _counterTop, nameof(_counterTop.SlotName));
            lblCounterTop2.DataBindings.Add("Text", _counterTop2, nameof(_counterTop2.SlotName));
            lblStoveSlot.DataBindings.Add("Text", _stove, nameof(_stove.SlotName));
            lblSink.DataBindings.Add("Text", _sink, nameof(_sink.SlotName));
            lblTableItemPlaced.DataBindings.Add("Text", _table, nameof(_table.SlotName));

            Binding plateRackBinding = new Binding("Text", _plateRack, nameof(_plateRack.CurrentCount));
            plateRackBinding.Format += (s, e) =>
            {
                e.Value = $"{e.Value}/{_plateRack.MaxCapcity}";
            };
            lblPlateRack.DataBindings.Add(plateRackBinding);

            pbStove.Minimum = 0;
            pbStove.Maximum = 100;
            pbStove.Value = 0;

            _timer.Interval = 100;
            _timer.Tick += (s, e) => _timer_Update();
            _timer.Start();

            _holdTimer.Interval = 100;
            _holdTimer.Tick += (s, e) => _holdTimer_Update();

            btnSinkClean.MouseDown += btnSinkClean_MouseDown;
            btnSinkClean.MouseUp += btnSinkClean_MouseUp;

            btnSinkClean.MouseLeave += btnSinkClean_MouseLeave;

            _EatingTimer.Interval = 100;
            _EatingTimer.Tick += (s, e) => _EatingTimer_Update();
            _EatingTimer.Start();
        }

        private void HungryPeople_Load(object sender, EventArgs e)
        {

        }

        // gets raw steak
        private void btnSteakFridge_Click(object sender, EventArgs e)
        {
            if (_player.HandItem?.ID == _steakFridge.SourceItem.ID)
            {
                bool removeItem = _steakFridge.PutItemInPantry(_player.HandItem);
                if (removeItem)
                    _player.RemoveFromHand();
                else
                    return;
            }
            else
            {
                Item itemFromPantry = _steakFridge.TakeItemFromPantry();
                Debug.WriteLine(itemFromPantry.Name);
                _player.AddToHand(itemFromPantry);
            }
        }

        // put items in counter top
        private void btnCounterTop_Click(object sender, EventArgs e)
        {

            if (_player.IsHandOccupied) // Puts Item
            {
                // Now first checks if the item can be place in stove, if yes then places otherwise exits

                bool WasItemPlaced = _counterTop.AddToCounterTop(_player.HandItem);
                if (WasItemPlaced)
                {
                    _player.RemoveFromHand();
                }

                return;

            }
            else if (!_player.IsHandOccupied && _counterTop.IsSlotOccupied) // Takes item
            {
                Item? item = _counterTop.RemoveFromCounterTop();
                bool WasItemTaken = _player.AddToHand(item);

                if (!WasItemTaken)
                {
                    _counterTop.AddToCounterTop(item);
                }
            }
        }
        private void btnCounterTop2_Click(object sender, EventArgs e)
        {
            if (_player.IsHandOccupied) // Puts Item
            {
                // Now first checks if the item can be place in stove, if yes then places otherwise exits

                bool WasItemPlaced = _counterTop2.AddToCounterTop(_player.HandItem);
                if (WasItemPlaced)
                {
                    _player.RemoveFromHand();
                }

                return;

            }
            else if (!_player.IsHandOccupied && _counterTop2.IsSlotOccupied) // Takes item
            {
                Item? item = _counterTop2.RemoveFromCounterTop();
                bool WasItemTaken = _player.AddToHand(item);

                if (!WasItemTaken)
                {
                    _counterTop2.AddToCounterTop(item);
                }
            }
        }

        // put items in stove
        private void btnStove_Click(object sender, EventArgs e)
        {
            if (_player.IsHandOccupied && !_stove.IsOccupied) // Puts Item
            {
                // Now first checks if the item can be place in stove, if yes then places otherwise exits

                bool WasItemPlaced = _stove.AddToSlot(_player.HandItem);
                if (WasItemPlaced)
                {
                    Item? item = _player.RemoveFromHand();
                    _stove.StartCooking();
                }

                return;

            }
            else if (!_player.IsHandOccupied && _stove.IsOccupied) // Takes item
            {
                Item? item = _stove.RemoveFromSlot();
                _player.AddToHand(item);
            }
        }

        // plate rack
        private void btnPlateRack_Click(object sender, EventArgs e)
        {

            // First checking if the player has a plate
            // Also, this won't allow to take a plate when a plate is already in hand
            if (_player.IsHandOccupied && _player.HandItem?.ID == _plateRack.Holds.ID)
            {
                bool wasAbleToPutBack = _plateRack.PutBack(_player.HandItem);
                if (wasAbleToPutBack)
                {
                    _player.RemoveFromHand();
                }

                Debug.WriteLine("Serving Plate hash: " + _player.HandItem.GetHashCode());
            }
            else
            {
                Item? plate = _plateRack.Take();
                _player.AddToHand(plate);
            }
        }

        // sink
        private void btnSinkInteract_Click(object sender, EventArgs e)
        {
            if (_player.IsHandOccupied && _player.HandItem is Cutlery cutlery)
            {
                bool WasItemPlaced = _sink.AddToSlot(cutlery);
                if (WasItemPlaced)
                {
                    _player.RemoveFromHand();
                }
            }
            else if (!_player.IsHandOccupied && _sink.IsSlotOccupied)
            {
                Item? item = _sink.RemoveFromSlot();
                bool WasItemTaken = _player.AddToHand(item);
                if (!WasItemTaken)
                {
                    _sink.AddToSlot((Cutlery)item);
                }
            }
        }

        // table
        private void btnTableInteract_Click(object sender, EventArgs e)
        {
            if (_player.IsHandOccupied)
            {
                bool WasItemPlaced = _table.AddToSlot(_player.HandItem);
                if (WasItemPlaced)
                {
                    _player.RemoveFromHand();

                    _customer.StartConsuming();



                }
            }
            else if (!_player.IsHandOccupied)
            {
                Item? item = _table.RemoveFromSlot();
                bool WasItemTaken = _player.AddToHand(item);
                if (!WasItemTaken)
                {
                    _table.AddToSlot((Cutlery)item);
                }
            }
        }

        private void btnSinkClean_MouseUp(object sender, MouseEventArgs e)
        {
            _holdTimer.Stop();
        }
        private void btnSinkClean_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_sink.CleaningTimer.IsRunning) // timer not running
            {
                _sink.StartCleaning();
            }

            _holdTimer.Start();
        }
        private void btnSinkClean_MouseLeave(object? sender, EventArgs e)
        {
            _holdTimer.Stop();

        }

        // Timers
        private void _timer_Update()

        {
            float deltaTime = 0.1f;

            _stove.CookTimer.Update(deltaTime);
            WasCookingInterpted();
            _stove.BurnTimer.Update(deltaTime);

            UpdateProgressBar();
        }
        private void _EatingTimer_Update()
        {
            float deltaTime = 0.1f;

            _customer.ConsumingTimer.Update(deltaTime);

            int progressBarValue = 0;

            if (_customer.ConsumingTimer.IsRunning)
            {
                float RemainingTime = _customer.ConsumingTimer.GetTimeRemaning();
                float TotalTime = _customer.Order.ConsumingTime;

                float percent = 1 - (RemainingTime / TotalTime);

                progressBarValue = (int)(percent * 100);
            }

            pbTable.Value = progressBarValue;

        }
        private void _holdTimer_Update()
        {
            float deltaTime = 0.1f;

            UpdateSinkProgressBar();
        }

        private void UpdateProgressBar()
        {
            int progressBarValue = 0;

            if (_stove.CookTimer.IsRunning)
            {
                float RemainingTime = _stove.CookTimer.GetTimeRemaning();
                float TotalTime = _stove.ActiveRecipe.PreperationTime * _stove.PreperationMultiplier;

                float percent = 1 - (RemainingTime / TotalTime);

                progressBarValue = (int)(percent * 100);

                //Debug.WriteLine(progressBarValue, "prep time");
            }
            else if (_stove.BurnTimer.IsRunning)
            {
                float RemainingTime = _stove.BurnTimer.GetTimeRemaning();
                float TotalTime = _stove.ActiveRecipe.BurnTime * _stove.BurnMultiplier;

                float percent = 1 - (RemainingTime / TotalTime);

                progressBarValue = (int)(percent * 100);

                Debug.WriteLine(progressBarValue + "burn time");

                pbStove.BackColor = Color.Red;
            }

            pbStove.Value = progressBarValue;
        }

        private void UpdateSinkProgressBar()
        {
            int progressBarValae = 0;

            if (_sink.CleaningTimer.IsRunning)
            {
                float RemainingTime = _sink.CleaningTimer.GetTimeRemaning();
                float TotalTime = _sink.Slot.CleaningTime * _sink.CleaningMultiplier;

                float percent = 1 - (RemainingTime / TotalTime);
                progressBarValae = (int)(progressBarValae * 100);
            }

            pbSink.Value = progressBarValae;
        }

        private void WasCookingInterpted()
        {
            if (_stove.CookTimer.IsRunning && !_stove.IsOccupied)
            {
                _stove.CookTimer.Stop();
            }
        }

        private void UpdateOrderUI()
        {

            if (_customer == null)
            {
                lblTableOrder.Text = "No Order";
                return;
            }

            Debug.WriteLine(_customer.Order.Name);

            lblTableOrder.Text = _customer.Order?.Name ?? "No Order";
        }

        
    }
}
