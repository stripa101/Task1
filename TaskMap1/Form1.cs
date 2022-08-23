using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using TaskMap1.Models;
namespace TaskMap1
{
    public partial class Form1 : Form
    {

        private IEnumerable<Equipment> _equipmentsList;
        public Form1()
        {
            InitializeComponent();
            using (var equipmentRepository = new GeographicalCoordinatesOnEquipment())
            {
                _equipmentsList = equipmentRepository.GetAll;
                gMapControl1.Overlays.Add(GetOverlayMarkers(_equipmentsList.ToList(), "l1"));
            }
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 16;
            gMapControl1.Zoom = 2;
            gMapControl1.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.ShowCenter = false;
        }
        private GMarkerGoogle GetMarker(Equipment equipment, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
        {
            var mapMarker = new GMarkerGoogle(new GMap.NET.PointLatLng((double)equipment.X, (double)equipment.Y), gMarkerGoogleType);
            mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);
            mapMarker.ToolTipText = equipment.Name;
            mapMarker.Tag = equipment;
            mapMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            return mapMarker;
        }
        private GMapOverlay GetOverlayMarkers(List<Equipment> listEquipment, string name, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
        {
            GMapOverlay gMapMarkers = new GMapOverlay(name);
            foreach (var item in listEquipment)
            {
                gMapMarkers.Markers.Add(GetMarker(item, gMarkerGoogleType));
            }
            return gMapMarkers;
        }

        private GMapMarker _item;
       
        private void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            _item = gMapControl1.Overlays.SelectMany(x => x.Markers).FirstOrDefault(y => y.IsMouseOver == true);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (var saveChange = new SaveDB())
            {
                saveChange.SetAll = _equipmentsList;
            }
        }

        
    }
}
