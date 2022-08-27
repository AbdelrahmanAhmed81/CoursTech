import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/models/Course';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent implements OnInit {
  params: HttpParams = new HttpParams().append('expand', 'Industry.Courses').append('expand', 'Instructor.Courses');
  course: Course | undefined;
  constructor(private courseService: CourseService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(data => {
      this.courseService.getById(data['id'], this.params).subscribe(data => {
        this.course = data;
        console.log(data)
      })
    })
  }
}
