import { Component } from '@angular/core';
import { PackageService } from '../../shared/services/package.service';



@Component({
  selector: 'app-package-list',
  templateUrl: './package-list.component.html',
  styleUrls: ['./package-list.component.css']
})
export class PackageListComponent {

  listPackages: any = [];

  constructor(private packageService: PackageService) {


    this.packageService.subject.subscribe(
      {
        next: (v: any) => {
         this.listPackages = [];
          v.forEach(element => {
            this.listPackages.push({ name: element.package.name })
          });
        }
      }
    );

    this.packageService.subject1.subscribe(

      {
        next: (v: { start: any, end: any }) => this.listPackages.forEach((element) => {
          this.packageService.getCurrentDownload(element.name, v.start, v.end).subscribe(p =>
            element.download = p.downloads)
        })
      })
  }
}


