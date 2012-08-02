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

            InitDatagrids();

        }
        
        private void InitDatagrids()
        {
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

       
        private void buttonScriptDirectory_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            var risp = fb.ShowDialog();
            if (risp != DialogResult.OK)
                return;

            var folder = fb.SelectedPath;

            _sdk.InitializeFactories(folder);
            _sdk.Populate();

            DataGridBinding();
        }


        private void DataGridBinding()
        {
            ColumndataGridColorAreaColor.DataPropertyName = "Color";
            ColumndataGridColorAreaName.DataPropertyName = "Name";
            ColumndataGridColorAreaLow.DataPropertyName = "Low";
            ColumndataGridColorAreaHight.DataPropertyName = "Hight";
            dataGridColorArea.AutoGenerateColumns = false;
            dataGridColorArea.DataSource = _sdk.ColorArea.List;

            ColumndataGridColorCoastColor.DataPropertyName = "Color";
            ColumndataGridColorCoastName.DataPropertyName = "Name";
            ColumndataGridColorCoastMinZ.DataPropertyName = "Low";
            ColumndataGridColorCoastMaxZ.DataPropertyName = "Hight";
            dataGridColorCoast.AutoGenerateColumns = false;
            dataGridColorCoast.DataSource = _sdk.ColorCoast.List;


            ColumndataGridMountainsColor.DataPropertyName = "Color";
            ColumndataGridMountainsName.DataPropertyName = "Name";
            ColumndataGridMountainsLow.DataPropertyName = "Low";
            ColumndataGridMountainsHight.DataPropertyName = "Hight";
            dataGridMountains.AutoGenerateColumns = false;
            dataGridMountains.DataSource = _sdk.ColorMountains.List;


            ColumndataGridSmoothItemsName.DataPropertyName = "Name";
            ColumndataGridSmoothItemsColorFrom.DataPropertyName = "ColorFrom";
            ColumndataGridSmoothItemsColorTo.DataPropertyName = "ColorTo";
            dataGridSmoothItems.AutoGenerateColumns = false;
            dataGridSmoothItems.DataSource = _sdk.Smooths.List;


            ColumndataGridTextureSmoothColorFrom.DataPropertyName = "ColorFrom";
            ColumndataGridTextureSmoothColorTo.DataPropertyName = "ColorTo";
            ColumndataGridTextureSmoothName.DataPropertyName = "Name";
            dataGridTexturesList.AutoGenerateColumns = false;
            dataGridTexturesList.DataSource = _sdk.TextureArea.List;


            ColumndataGridCliffsListColorFrom.DataPropertyName = "ColorFrom";
            ColumndataGridCliffsListColorTo.DataPropertyName = "ColorTo";
            ColumndataGridCliffsListName.DataPropertyName = "Name";
            dataGridCliffsList.AutoGenerateColumns = false;
            dataGridCliffsList.DataSource = _sdk.Cliffs.List;
        }

        #region SizeFunctions
        private void MapMakerControl_SizeChanged(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void TabControlDataHandler_SizeChanged(object sender, EventArgs e)
        {
            TabControlDataHandler.Dock = DockStyle.Bottom;
        }
        #endregion
    }
}
