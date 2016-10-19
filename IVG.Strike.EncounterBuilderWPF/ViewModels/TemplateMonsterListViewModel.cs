using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class TemplateMonsterListViewModel : Conductor<PropertyChangedBase>
    {
        private MainViewModel _parent;
        public TemplateMonsterListViewModel(MainViewModel parent)
        {
            _parent = parent;
        }

        public BindableCollection<Models.TemplateMonsterModel> Templates
        {
            get { return _parent.Templates; }
        }


        private Models.TemplateMonsterModel _selectedTemplate;
        public Models.TemplateMonsterModel SelectedTemplate
        {
            get { return _selectedTemplate; }
            set
            {
                if (_selectedTemplate != value)
                {
                    _selectedTemplate = value;

                    if (value != null)
                        ActivateItem(new TemplateMonsterViewModel(value, _parent, false));

                    NotifyOfPropertyChange(() => SelectedTemplate);
                    NotifyOfPropertyChange(() => CanDelTemplate);
                    NotifyOfPropertyChange(() => CanAddMonsterFromTemplate);
                }
            }
        }

        public bool CanDelTemplate
        {
            get { return _selectedTemplate != null; }
        }


        public void AddTemplate()
        {
            Models.TemplateMonsterModel m = Models.TemplateMonsterModel.NewTemplateMonsterModel();
            _parent.Templates.Add(m);
            SelectedTemplate = m;
        }
        public void DelTemplate()
        {
            DeactivateItem(ActiveItem, true);

            _parent.Templates.Remove(SelectedTemplate);

            SelectedTemplate = null;
        }

        public void AddMonsterFromTemplate()
        {
            WindowManager wm = new WindowManager();

            Dictionary<string, object> settings = new Dictionary<string, object>();
            settings.Add("Height", 500);
            settings.Add("Width", 500);
            settings.Add("SizeToContent", System.Windows.SizeToContent.Manual);

            AddMonsterFromTemplateViewModel amftvm = new AddMonsterFromTemplateViewModel();
            bool? success = wm.ShowDialog(amftvm, null, settings);

            if (success == true)
            {
                _parent.Monsters.Add(SelectedTemplate.GetMonster(amftvm.SelectedLevel, (Models.MonsterType)Enum.Parse(typeof(Models.MonsterType), amftvm.SelectedMonsterType), amftvm.MonsterName, amftvm.MonsterText));
            }
        }
        public bool CanAddMonsterFromTemplate
        {
            get { return _selectedTemplate != null; }
        }
    }
}
