import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { UserParams } from 'src/app/_models/userParams';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { GENDER_LIST } from 'src/app/util/constants';
import { Job } from 'src/app/_models/job';
import { JobsParams } from 'src/app/_models/jobParams';
import { JobsService } from 'src/app/_services/jobs.service';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements OnInit {
  jobs: Job [];
  pagination: Pagination;

  jobParams: JobsParams;

  genderList = GENDER_LIST;

  constructor(private memberService: MembersService, private jobsService: JobsService) {
    this.jobParams = this.jobsService.getUserParams();

  }

  ngOnInit(): void {
    this.jobs = [{
      id: 10,
      title: "Hello",
      orgId: 12,
      jobPosterId: 1,
      logoUrl: "https://randomuser.me/api/portraits/men/93.jpg",
      description: "Need farm work who can feed cows",
      salary: 2,
      city: "Pizza Land",
      province: "Vegas",
      country: "Italy",
      genres: "Strong, Talented",
      jobType: "Hard",
      skillsRequired: "Farming, Mooing, Grass eating",
      applicationUrl: "https://randomuser.me/api/portraits/men/93.jpg",
      dateCreated: new Date(Date.now()),
      deadline: new Date(Date.now()),
      lastUpdated: new Date(Date.now())
    }]
    //this.loadMembers();
  }

  loadMembers() {
    this.jobsService.setUserParams(this.jobParams);

    this.jobsService.getJobs(this.jobParams).subscribe((response) => {
      this.jobs = response.result;
      this.pagination = response.pagination;
    });



  }

  resetFilters() {
    this.jobParams = this.jobsService.resetUserParams();
    this.loadMembers();
  }

  pageChanged(event: any) {
    this.jobParams.pageNumber = event.page;
    this.jobsService.setUserParams(this.jobParams);
    this.loadMembers();
  }
}
