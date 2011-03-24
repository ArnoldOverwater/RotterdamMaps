import com.google.maps.Map;
import com.google.maps.MapEvent;
import com.google.maps.MapType;
import com.google.maps.LatLng;

import com.google.maps.controls.NavigationControl;
import com.google.maps.controls.PositionControl;
import com.google.maps.controls.ScaleControl;
import com.google.maps.controls.ZoomControl;

private static var ROTTERDAM_LL : LatLng = new LatLng(51.9178416916685, 4.48117733001709, false);
private static var ROTTERDAM_ZOOM : int = 11;

private static var NAVIGATION : NavigationControl = new NavigationControl();
private static var SCALE : ScaleControl = new ScaleControl();

private function onMapReady(event : Event) : void {
	map.setCenter(ROTTERDAM_LL, ROTTERDAM_ZOOM, MapType.NORMAL_MAP_TYPE);
	map.addControl(NAVIGATION);
	map.addControl(SCALE);
}
