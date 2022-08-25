import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CourseTech';
  isDark: boolean = false;
  onChangeMode(data: boolean) {
    this.isDark = data;
    document.body.classList.toggle('darkmode');
  }

}
