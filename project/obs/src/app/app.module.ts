import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { PackageInputComponent } from './componnet/package-input/package-input.component';
import { TimeRangeInputComponent } from './componnet/time-range-input/time-range-input.component';
import { PackageListComponent } from './componnet/package-list/package-list.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    PackageInputComponent,
    TimeRangeInputComponent,
    PackageListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
