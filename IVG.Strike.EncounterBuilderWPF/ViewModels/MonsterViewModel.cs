using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class MonsterViewModel : Conductor<PropertyChangedBase>.Collection.AllActive
    {
        private Models.MonsterModel _model;
        private MainViewModel _parent;
        public MonsterViewModel(Models.MonsterModel monster, MainViewModel parent, bool readOnly)
        {
            _model = monster;
            _parent = parent;
            _selectedMonsterType = _model.Type.ToString();
        }
        public BindableCollection<Models.PowerModel> Powers
        {
            get { return _model.Powers; }
        }
        private Models.PowerModel _selectedPower;
        public Models.PowerModel SelectedPower
        {
            get { return _selectedPower; }
            set
            {
                if (_selectedPower != value)
                {
                    _selectedPower = value;

                    //ActivateItem(new PowerViewModel(value));
                    SelectedPowerVM = new PowerViewModel(value);

                    NotifyOfPropertyChange(() => SelectedPower);
                    NotifyOfPropertyChange(() => CanDelPower);
                }
            }
        }
        private PowerViewModel _selectedPowerVM;
        public PowerViewModel SelectedPowerVM
        {
            get { return _selectedPowerVM; }
            set
            {
                if (_selectedPowerVM != value)
                {
                    _selectedPowerVM = value;
                    NotifyOfPropertyChange(() => SelectedPowerVM);
                }
            }
        }
        private Models.TraitModel _selectedTrait;
        public Models.TraitModel SelectedTrait
        {
            get { return _selectedTrait; }
            set
            {
                if (_selectedTrait != value)
                {
                    _selectedTrait = value;

                    //ActivateItem(new TraitViewModel(value, false));
                    SelectedTraitVM = new TraitViewModel(value, false);

                    NotifyOfPropertyChange(() => SelectedTrait);
                    NotifyOfPropertyChange(() => CanDelTrait);
                }
            }
        }
        private TraitViewModel _selectedTraitVM;
        public TraitViewModel SelectedTraitVM
        {
            get { return _selectedTraitVM; }
            set
            {
                if (_selectedTraitVM != value)
                {
                    _selectedTraitVM = value;
                    NotifyOfPropertyChange(() => SelectedTraitVM);
                }
            }
        }
        public BindableCollection<Models.TraitModel> Traits
        {
            get { return _model.Traits; }
            set
            {
                SelectedTrait = null;
                SelectedTraitVM = null;
                _model.Traits = value;
                NotifyOfPropertyChange(() => Traits);
            }
        }
        public void AddPower()
        {
            Models.PowerModel m = Models.PowerModel.NewPowerModel();
            _model.Powers.Add(m);
            SelectedPower = m;
        }
        public void AddTrait()
        {
            Models.TraitModel m = Models.TraitModel.NewTraitModel();
            _model.Traits.Add(m);
            SelectedTrait = m;
        }
        public void DelPower()
        {
            //DeactivateItem(ActiveItem, true);

            _model.Powers.Remove(SelectedPower);

            SelectedPower = null;
        }
        public void DelTrait()
        {
            //DeactivateItem(ActiveItem, true);

            _model.Traits.Remove(SelectedTrait);

            SelectedTrait = null;
        }
        public bool CanDelPower { get { return _selectedPower != null; } }
        public bool CanDelTrait { get { return _selectedTrait != null; } }

        public List<string> MonsterTypes
        {
            get
            {
                return Enum.GetNames(typeof(Models.MonsterType)).ToList();
            }
        }
        private string _selectedMonsterType;
        public string SelectedMonsterType
        {
            get { return _selectedMonsterType; }
            set
            {
                if (_selectedMonsterType != value)
                {
                    _selectedMonsterType = value;
                    _model.Type = (Models.MonsterType)Enum.Parse(typeof(Models.MonsterType), _selectedMonsterType);
                    NotifyOfPropertyChange(() => SelectedMonsterType);
                }
            }
        }

        public void AddTraitsFromList()
        {
            WindowManager wm = new WindowManager();

            Dictionary<string, object> settings = new Dictionary<string, object>();
            settings.Add("Height", 400);
            settings.Add("Width", 650);
            settings.Add("SizeToContent", System.Windows.SizeToContent.Manual);

            AddMonsterTraitsViewModel amtvm = new AddMonsterTraitsViewModel(_parent.Traits, this.Traits);
            wm.ShowDialog(amtvm, null, settings);
            amtvm.MonsterTraits.ToList().ForEach(t => this.Traits.Add(t.Clone()));
        }
        public bool CanAddTraitsFromList
        {
            get { return _parent != null; }
        }
        public int Level
        {
            get { return _model.Level; }
            set { if (_model.Level != value) { _model.Level = value; NotifyOfPropertyChange(() => Level); } }
        }

        public string MonsterName
        {
            get { return _model.Name; }
            set { if (_model.Name != value) { _model.Name = value; NotifyOfPropertyChange(() => MonsterName); } }
        }

        public string MonsterText
        {
            get { return _model.Text; }
            set { if (_model.Text != value) { _model.Text = value; NotifyOfPropertyChange(() => MonsterText); } }
        }

        public int HitPoints
        {
            get { return _model.HitPoints; }
            set { if (_model.HitPoints != value) { _model.HitPoints = value; NotifyOfPropertyChange(() => HitPoints); } }
        }

        public int Size
        {
            get { return _model.Size; }
            set { if (_model.Size != value) { _model.Size = value; NotifyOfPropertyChange(() => Size); } }
        }

        public int Speed
        {
            get { return _model.Speed; }
            set { if (_model.Speed != value) { _model.Speed = value; NotifyOfPropertyChange(() => Speed); } }
        }
    }
}
