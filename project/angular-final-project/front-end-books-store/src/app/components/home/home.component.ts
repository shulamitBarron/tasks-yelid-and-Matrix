import { Component } from '@angular/core';
import { LocationStore } from '../../shared/models/location.model'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  locationStore:LocationStore;
  constructor() {
    this.locationStore.city = "Tel Aviv";
    this.locationStore.streetName = "Hamasger St.";
    this.locationStore.houseNumber = 12;
  }


}
