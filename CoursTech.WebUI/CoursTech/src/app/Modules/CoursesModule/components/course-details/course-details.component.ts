import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { Course } from 'src/app/models/Course';
import { CourseService } from 'src/app/Modules/CoursesModule/services/course.service';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent implements OnInit {
  params: HttpParams = new HttpParams().append('expand', 'Industry.Courses').append('expand', 'Instructor.Courses');
  course: Course | undefined;
  isLoading: boolean = false;
  constructor(private courseService: CourseService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.route.params.subscribe(data => {
      this.courseService.getById(data['id'], this.params)
        .pipe(map(data => {
          let duration = data.duration.split(':');
          data.duration = `${duration[0]}h ${duration[1]}m`

          if (data.imageName)
            data.imageName = CourseService.images_path + data.imageName;
          if (data.instructor?.photoName)
            data.instructor.photoName = CourseService.instructor_photos_path + data.instructor.photoName;
          if (data.industry?.courses) {
            data.industry.courses.map(c => {
              c.imageName = CourseService.images_path + c.imageName;
            })
          }
          if (data.instructor?.courses) {
            data.instructor.courses.map(c => {
              c.imageName = CourseService.images_path + c.imageName;
            })
          }
          return data;
        }))
        .subscribe(data => {
          this.course = data;
          this.isLoading = false;
        })
    })
  }
}
