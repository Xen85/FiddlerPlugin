using System.Windows.Forms;
using MapMakerFiddler;
using OpenUO.MapMaker;
using PluginInterface;

namespace FiddlerPlugin
{
    public class PluginPresentationMapMaker : IPlugin
    {
        public static MakeMapSDK SDK;
        public MapMakerFiddler.MapMakerControl MapControl;
        private const string _name = "Fiddler Map Maker";
        private const string _description = "Make the map muls from a bitmap";
        private const string _author = @"Xen - Age of Fall ";
        private const string _ver = "0.001";


        public override IPluginHost Host{get ; set; }

        public override string Name
        {
            get { return _name; }
        }

        public override string Description
        {
            get { return _description; }
        }

        public override string Author
        {
            get { return _author; }
        }

        public override string Version
        {
            get { return _ver; }
        }

        public override void Initialize()
        {
            SDK = new MakeMapSDK();
        }

        public override void Dispose()
        {
            SDK = null;
        }

        /// <summary>
        /// I add mycontrol to uofiddler
        /// </summary>
        /// <param name="tabcontrol"></param>
        public override void ModifyTabPages(TabControl tabcontrol)
        {
            TabPage page = new TabPage {Name = "Map Maker", Tag = tabcontrol.TabCount + 1};
            tabcontrol.TabPages.Add(page);
            MapControl = new MapMakerControl();
            MapControl.Dock = DockStyle.Fill;
            page.Text = @"MapMaker";
            page.Controls.Add(MapControl);

        }
    }
}
