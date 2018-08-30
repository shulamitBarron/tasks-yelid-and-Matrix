import { Component } from '@angular/core';
import { PackageService } from '../../shared/services/package.service';

@Component({
  selector: 'app-time-range-input',
  templateUrl: './time-range-input.component.html',
  styleUrls: ['./time-range-input.component.css']
})
export class TimeRangeInputComponent {
  
  endTime :Date;
  startTime :Date;
  constructor(private packageService:PackageService) { }
  check() {
   // if(this.startTime&&this.endTime)
   this.packageService.subject1.next({start:this.startTime,end:this.endTime});
  }

}
