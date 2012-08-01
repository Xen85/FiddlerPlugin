using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenUO.MapMaker;

namespace MapMakerFiddler
{
    public partial class MapMakerControl : UserControl
    {
        private readonly MakeMapSDK _sdk;
        public MapMakerControl()
        {
            InitializeComponent();
            _sdk = FiddlerPlugin.PluginPresentationMapMaker.SDK;

            dataGridColorArea.DataSource = _sdk.ColorArea.List;
            dataGridColorCoast.DataSource = _sdk.ColorCoast.List;
            dataGridMountains.DataSource = _sdk.ColorMountains.List;

            DataGridItemsView.DataSource = _sdk.Items.List;
            dataGridSmoothItems.DataSource = _sdk.Smooths.List;
            DataGridItemsCoastSelector.DataSource = _sdk.ItemsCoasts.List;

            dataGridTexturesList.DataSource = _sdk.TextureArea.List;
            dataGridCliffsList.DataSource = _sdk.Cliffs.List;
            dataGridTextureSmooth.DataSource = _sdk.SmoothTextures.List;

        }



    }
}
