using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using System.IO;
using System.Xml;
using Newtonsoft.Json;


namespace IVG.Strike.EncounterBuilderWPF.ViewModels
{
    public class MainViewModel: Conductor<PropertyChangedBase>
    {
        private string _dataPath;
        public MainViewModel()
        {
            DisplayName = "Strike! Encounter Builder";
            _monsters = new BindableCollection<Models.MonsterModel>();
            _traits = new BindableCollection<Models.TraitModel>();
            _templates = new BindableCollection<Models.TemplateMonsterModel>();
            _dataPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StrikeRPG\\Data\\");

            Models.SystemModel sys = null;

            if (!Directory.Exists(_dataPath))
                Directory.CreateDirectory(_dataPath);
            //if (!File.Exists(System.IO.Path.Combine(_dataPath, "monsters.xml")))
            //{
            //    using (StreamWriter ResourceFile = new StreamWriter(new FileStream(System.IO.Path.Combine(_dataPath, "data.xml"), FileMode.Create)))
            //    using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LastStand.Data.data.xml"))
            //    using (var reader = new StreamReader(stream))
            //    {
            //        ResourceFile.Write(reader.ReadToEnd());
            //        ResourceFile.Flush();
            //        ResourceFile.Close();
            //    }
            //}
            try
            {
                TextReader reader = new StreamReader(System.IO.Path.Combine(_dataPath, "data.json"));
                sys = JsonConvert.DeserializeObject<Models.SystemModel>(reader.ReadToEnd());
                reader.Close();

                _monsters = new BindableCollection<Models.MonsterModel>(sys.Monsters);
                _traits = new BindableCollection<Models.TraitModel>(sys.Traits);
                _templates = new BindableCollection<Models.TemplateMonsterModel>(sys.Templates);
            }
            catch (Exception)
            { }
            if (_monsters == null)
                _monsters = new BindableCollection<Models.MonsterModel>();
            if (_traits == null)
                _traits = new BindableCollection<Models.TraitModel>();
            if (_templates == null)
                _templates = new BindableCollection<Models.TemplateMonsterModel>();

            if (_monsters.Count > 0) SelectedMonster = _monsters[0];
            if (_templates.Count > 0) SelectedTemplate = _templates[0];

        }

        private BindableCollection<Models.MonsterModel> _monsters;
        public BindableCollection<Models.MonsterModel> Monsters
        {
            get { return _monsters; }
        }

        private BindableCollection<Models.TraitModel> _traits;
        public BindableCollection<Models.TraitModel> Traits
        {
            get { return _traits; }
        }

        private BindableCollection<Models.TemplateMonsterModel> _templates;
        public BindableCollection<Models.TemplateMonsterModel> Templates
        {
            get { return _templates; }
        }

        private Models.MonsterModel _selectedMonster;
        public Models.MonsterModel SelectedMonster
        {
            get { return _selectedMonster; }
            set
            {
                if (_selectedMonster != value)
                {
                    _selectedMonster = value;

                    if (value != null)
                        SelectedMonsterVM = new MonsterViewModel(value, this, false);
                    else
                        SelectedMonsterVM = null;

                    NotifyOfPropertyChange(() => SelectedMonster);
                    NotifyOfPropertyChange(() => CanDelMonster);
                }
            }
        }

        private MonsterViewModel _selectedMonsterVM;
        public MonsterViewModel SelectedMonsterVM
        {
            get { return _selectedMonsterVM; }
            set
            {
                if (_selectedMonsterVM != value)
                {
                    _selectedMonsterVM = value;

                    NotifyOfPropertyChange(() => SelectedMonsterVM);
                }
            }
        }

        public void AddMonster()
        {
            Models.MonsterModel m = Models.MonsterModel.NewMonsterModel();
            _monsters.Add(m);
            SelectedMonster = m;
        }
        public void DelMonster()
        {
            DeactivateItem(ActiveItem, true);

            _monsters.Remove(SelectedMonster);
            
            SelectedMonster = null;
        }
        public bool CanDelMonster
        {
            get { return SelectedMonster != null; }
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

                    //if (value != null)
                    //    ActivateItem(new TemplateMonsterViewModel(value, _parent, false));

                    if (value != null)
                        SelectedTemplateVM = new TemplateMonsterViewModel(value, this, false);
                    else
                        SelectedTemplateVM = null;

                    NotifyOfPropertyChange(() => SelectedTemplate);
                    NotifyOfPropertyChange(() => CanDelTemplate);
                    NotifyOfPropertyChange(() => CanAddMonsterFromTemplate);
                }
            }
        }

        private TemplateMonsterViewModel _selectedTemplateVM;
        public TemplateMonsterViewModel SelectedTemplateVM
        {
            get { return _selectedTemplateVM; }
            set
            {
                if (_selectedTemplateVM != value)
                {
                    _selectedTemplateVM = value;

                    NotifyOfPropertyChange(() => SelectedTemplateVM);
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
            Templates.Add(m);
            SelectedTemplate = m;
        }
        public void DelTemplate()
        {
            DeactivateItem(ActiveItem, true);

            Templates.Remove(SelectedTemplate);

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
                Monsters.Add(SelectedTemplate.GetMonster(amftvm.SelectedLevel, (Models.MonsterType)Enum.Parse(typeof(Models.MonsterType), amftvm.SelectedMonsterType), amftvm.MonsterName, amftvm.MonsterText));
            }
        }
        public bool CanAddMonsterFromTemplate
        {
            get { return _selectedTemplate != null; }
        }

        public void BuildEncounter()
        {
            WindowManager wm = new WindowManager();

            Dictionary<string, object> settings = new Dictionary<string, object>();
            settings.Add("Height", 600);
            settings.Add("Width", 1000);
            settings.Add("SizeToContent", System.Windows.SizeToContent.Manual);

            var vm = new EncounterBuilderViewModel(_monsters);
            wm.ShowDialog(vm, null, settings);

        }

        //public void ShowTemplateMonsters()
        //{
        //    WindowManager wm = new WindowManager();

        //    Dictionary<string, object> settings = new Dictionary<string, object>();
        //    settings.Add("Height", 600);
        //    settings.Add("Width", 1000);
        //    settings.Add("SizeToContent", System.Windows.SizeToContent.Manual);

        //    TemplateMonsterListViewModel tmlvm = new TemplateMonsterListViewModel(this);
        //    wm.ShowDialog(tmlvm, null, settings);
        //}

        public void Save()
        {
            TextWriter writer = new StreamWriter(System.IO.Path.Combine(_dataPath, "data.json"));

            Models.SystemModel sys = new Models.SystemModel();

            sys.Monsters = _monsters.ToList();
            sys.Traits = _traits.ToList();
            sys.Templates = _templates.ToList();
            
            writer.Write(JsonConvert.SerializeObject(sys));
            writer.Flush();
            writer.Close();
        }

        public void Exit()
        {
            this.TryClose();
        }

        public void ShowFullTraitList()
        {
            WindowManager wm = new WindowManager();

            Dictionary<string, object> settings = new Dictionary<string, object>();
            settings.Add("Height", 500);
            settings.Add("Width", 500);
            settings.Add("SizeToContent", System.Windows.SizeToContent.Manual);

            var vm = new TraitListViewModel(_traits);
            wm.ShowDialog(vm, null, settings);
            _traits = vm.Traits;
        }

        public void PrintEncounter()
        {
            List<Models.MonsterPrintModel> l = new List<Models.MonsterPrintModel>();

            //Models.MonsterModel m = Monsters.FirstOrDefault(p => p.Name == "Plague Thrower");
            //m.Traits.Add(Traits.FirstOrDefault(p => p.Name == "Immune"));

            //m = Monsters.FirstOrDefault(p => p.Name == "Necrotic Wasp Swarm");
            //m.Traits.Add(Traits.FirstOrDefault(p => p.Name == "Delayed Initiative"));
            //m.Traits.Add(Traits.FirstOrDefault(p => p.Name == "Mob"));
            //m.Traits.Add(Traits.FirstOrDefault(p => p.Name == "Short Reach"));
            //m.Traits.Add(Traits.FirstOrDefault(p => p.Name == "Natural Flyer"));

            foreach (Models.MonsterModel m in Monsters)
                l.AddRange(m.GetPrintMonster());

            IVG.Strike.EncounterBuilderWPF.Views.MonsterPrintPreview mpv = new EncounterBuilderWPF.Views.MonsterPrintPreview(l);
            mpv.Owner = (Window)this.GetView();
            mpv.ShowDialog();
        }

        private int _selectedTab;
        public int SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                if (_selectedTab != value)
                {
                    _selectedTab = value;

                    NotifyOfPropertyChange(() => SelectedMonsterVisibility);
                    NotifyOfPropertyChange(() => SelectedTemplateVisibility);
                }
            }
        }

        public Visibility SelectedMonsterVisibility { get { return _selectedTab == 0 ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility SelectedTemplateVisibility { get { return _selectedTab == 1 ? Visibility.Visible : Visibility.Collapsed; } }
    }
}
