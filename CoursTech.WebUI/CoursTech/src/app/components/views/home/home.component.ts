import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  queryParams: HttpParams = new HttpParams()
    .append('pageNumber', 1)
    .append('pageCapacity', 2)
    .append('expand', 'industry');
  constructor() { }

  ngOnInit(): void {

  }
}
