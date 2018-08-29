import { Component } from '@angular/core';
import { Color } from './shared/models/colors.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  colors: Color[];
  currentColor :Color=0;

  get listColors(){
  return  Object.keys(Color).filter(x=>isNaN(Number(x)));
  }

  changeColor(newColor:number) {
    this.currentColor = newColor;
    document.body.style.backgroundColor = Color[this.currentColor];
  }
}
