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
    .append('pageCapacity', 5)
    .append('expand', 'Industry');
  totalCourses: number = 0;
  constructor() { }

  ngOnInit(): void {

  }
  onChangePagination(data: { pageNumber: number, itemsPerPage: number }) {
    this.queryParams = this.queryParams.set('pageNumber', data.pageNumber);
    this.queryParams = this.queryParams.set('pageCapacity', data.itemsPerPage);
  }
  onLoadCourses(totalCount: number) {
    this.totalCourses = totalCount
  }
}
