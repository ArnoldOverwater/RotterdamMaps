import com.google.maps.Map;
import com.google.maps.MapAction;
import com.google.maps.MapEvent;
import com.google.maps.MapMoveEvent;
import com.google.maps.MapZoomEvent;
import com.google.maps.MapType;
import com.google.maps.LatLng;
import com.google.maps.LatLngBounds;

import com.google.maps.controls.NavigationControl;
import com.google.maps.controls.ScaleControl;

import com.google.maps.overlays.Polygon;
import com.google.maps.overlays.Marker;

private static var ROTTERDAM_LL : LatLng = new LatLng(51.9178416916685, 4.48117733001709);
private static var ROTTERDAM_ZOOM : int = 13;

private static var MAX_ZOOM : int = 22;
private static var MIN_ZOOM : int = 12;
private static var ROTTERDAM_BOUND : LatLngBounds =
                     new LatLngBounds(
                       new LatLng(
                         51.835721, // South
                          4.365864  // West
                       ), new LatLng(
                         51.968328, // North
                          4.598293  // East
                       )
                     );

private static var NAVIGATION : NavigationControl = new NavigationControl();
private static var SCALE : ScaleControl = new ScaleControl();

private function onMapReady(event : Event) : void {
	map.setCenter(ROTTERDAM_LL, ROTTERDAM_ZOOM, MapType.NORMAL_MAP_TYPE);
	map.setDoubleClickMode(MapAction.ACTION_PAN);
	map.addEventListener(MapZoomEvent.ZOOM_CHANGED, onZoom);
	map.addEventListener(MapZoomEvent.CONTINUOUS_ZOOM_STEP, onZoom);
	map.addEventListener(MapMoveEvent.MOVE_END, onMove);
	map.enableContinuousZoom();
	map.enableDragging();
	map.enableScrollWheelZoom();
	map.addControl(NAVIGATION);
	map.addControl(SCALE);
	debugBounds();
}

private function onZoom(event : MapZoomEvent) : void {
	var zoom : int = event.zoomLevel;
	if (zoom < MIN_ZOOM)
		map.setZoom(MIN_ZOOM);
	else if (zoom > MAX_ZOOM)
		map.setZoom(MAX_ZOOM);
}

private function onMove(event : MapMoveEvent) : void {
	if (! ROTTERDAM_BOUND.containsLatLng(event.latLng)) {
		var lat : Number = event.latLng.lat();
		var lng : Number = event.latLng.lng();
		if (lat > ROTTERDAM_BOUND.getNorth())
			lat = ROTTERDAM_BOUND.getNorth();
		else if (lat < ROTTERDAM_BOUND.getSouth())
			lat = ROTTERDAM_BOUND.getSouth();
		if (lng > ROTTERDAM_BOUND.getEast())
			lng = ROTTERDAM_BOUND.getEast();
		else if (lng < ROTTERDAM_BOUND.getWest())
			lng = ROTTERDAM_BOUND.getWest();
		map.panTo(new LatLng(lat, lng));
//		map.panTo(ROTTERDAM_LL);
	}
}

private function debugBounds() : void {
	var bounds : Polygon = new Polygon(new Array(ROTTERDAM_BOUND.getNorthEast(), ROTTERDAM_BOUND.getNorthWest(), ROTTERDAM_BOUND.getSouthWest(), ROTTERDAM_BOUND.getSouthEast()));
	map.addOverlay(bounds);
	map.addOverlay(new Marker(ROTTERDAM_LL));
}