import { HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  queryParams: HttpParams = new HttpParams().append('expand', 'Industry');
  // .append('pageNumber', 1)
  // .append('pageCapacity', 5)
  pageNumber: number = 0;
  pageCapacity: number = 0;
  totalCourses: number = 0;
  constructor(private activatedRoute: ActivatedRoute, private router: Router) { }


  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe((params: Params) => {
      this.queryParams = this.queryParams.set('pageNumber', params['pnum'] ?? 1);
      this.queryParams = this.queryParams.set('pageCapacity', params['pcap'] ?? 5);
    })
  }

  onChangePagination(data: { pageNumber: number, pageCapacity: number }) {
    this.router.navigate(['/Home'], { queryParams: { 'pnum': data.pageNumber, 'pcap': data.pageCapacity } });
  }

  // onChangePagination(data: { pageNumber: number, itemsPerPage: number }) {
  //   this.queryParams = this.queryParams.set('pageNumber', data.pageNumber);
  //   this.queryParams = this.queryParams.set('pageCapacity', data.itemsPerPage);
  // }

  onLoadCourses(totalCount: number) {
    this.totalCourses = totalCount;
    this.pageNumber = this.activatedRoute.snapshot.queryParams['pnum'] ?? 1;
    this.pageCapacity = this.activatedRoute.snapshot.queryParams['pcap'] ?? 5;
  }
}
