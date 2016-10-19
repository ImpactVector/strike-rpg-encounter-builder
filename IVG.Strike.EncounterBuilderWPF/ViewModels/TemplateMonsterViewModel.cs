using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class TemplateMonsterViewModel : Conductor<PropertyChangedBase>.Collection.AllActive
    {
        private Models.TemplateMonsterModel _model;
        private MainViewModel _parent;
        public TemplateMonsterViewModel(Models.TemplateMonsterModel monster, MainViewModel parent, bool readOnly)
        {
            _model = monster;
            _parent = parent;
        }
        public BindableCollection<Models.TemplatePowerModel> Powers
        {
            get { return _model.Powers; }
        }
        private Models.TemplatePowerModel _selectedPower;
        public Models.TemplatePowerModel SelectedPower
        {
            get { return _selectedPower; }
            set
            {
                if (_selectedPower != value)
                {
                    _selectedPower = value;

                    //ActivateItem(new PowerViewModel(value));
                    SelectedPowerVM = new TemplatePowerViewModel(value);

                    NotifyOfPropertyChange(() => SelectedPower);
                    NotifyOfPropertyChange(() => CanDelPower);
                }
            }
        }
        private TemplatePowerViewModel _selectedPowerVM;
        public TemplatePowerViewModel SelectedPowerVM
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
        private Models.TemplateTraitModel _selectedTrait;
        public Models.TemplateTraitModel SelectedTrait
        {
            get { return _selectedTrait; }
            set
            {
                if (_selectedTrait != value)
                {
                    _selectedTrait = value;

                    //ActivateItem(new TraitViewModel(value, false));
                    SelectedTraitVM = new TemplateTraitViewModel(value, false);

                    NotifyOfPropertyChange(() => SelectedTrait);
                    NotifyOfPropertyChange(() => CanDelTrait);
                }
            }
        }
        private TemplateTraitViewModel _selectedTraitVM;
        public TemplateTraitViewModel SelectedTraitVM
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
        public BindableCollection<Models.TemplateTraitModel> Traits
        {
            get { return _model.Traits; }
        }
        public void AddPower()
        {
            Models.TemplatePowerModel m = Models.TemplatePowerModel.NewTemplatePowerModel();
            m.EffectiveLevels = new HashSet<int>(new int[] { 2, 4, 6, 8, 10, 12 });
            _model.Powers.Add(m);
            SelectedPower = m;
        }
        public void AddTrait()
        {
            Models.TemplateTraitModel m = Models.TemplateTraitModel.NewTemplateTraitModel();
            m.EffectiveLevels = new HashSet<int>(new int[] { 2, 4, 6, 8, 10, 12 });
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

        public void AddTraitsFromList()
        {
            WindowManager wm = new WindowManager();

            Dictionary<string, object> settings = new Dictionary<string, object>();
            settings.Add("Height", 400);
            settings.Add("Width", 650);
            settings.Add("SizeToContent", System.Windows.SizeToContent.Manual);

            AddMonsterTraitsViewModel amtvm = new AddMonsterTraitsViewModel(_parent.Traits, new BindableCollection<Models.TraitModel>());
            wm.ShowDialog(amtvm, null, settings);
            amtvm.MonsterTraits.ToList().ForEach(t => this.Traits.Add(Models.TemplateTraitModel.NewTemplateTraitModel(t)));
        }
        public bool CanAddTraitsFromList
        {
            get { return _parent != null; }
        }

        public string TemplateName
        {
            get { return _model.Name; }
            set { if (_model.Name != value) { _model.Name = value; NotifyOfPropertyChange(() => TemplateName); } }
        }

        public string TemplateText
        {
            get { return _model.Text; }
            set { if (_model.Text != value) { _model.Text = value; NotifyOfPropertyChange(() => TemplateText); } }
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

        public bool IsSpecialist
        {
            get { return _model.IsSpecialist; }
            set { if (_model.IsSpecialist != value) { _model.IsSpecialist = value; NotifyOfPropertyChange(() => IsSpecialist); } }
        }
    }
}
