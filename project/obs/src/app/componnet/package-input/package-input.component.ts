import { Component } from '@angular/core';
import { PackageService } from '../../shared/services/package.service';

@Component({
  selector: 'app-package-input',
  templateUrl: './package-input.component.html',
  styleUrls: ['./package-input.component.css']
})
export class PackageInputComponent {


  constructor(private packageService: PackageService) {

  }


  keyUp(event) : void{
    this.packageService.getCurrentListPackages(event.target.value)
      .subscribe(list => {this.packageService.subject.next(list);})

  }

}
