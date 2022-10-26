import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesNavigatorComponent } from './components/pages-navigator/pages-navigator.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PagesNavigatorComponent
  ],
  imports: [
    FormsModule
  ],
  exports: [
    PagesNavigatorComponent,
  ]
})
export class SharedModule { }
