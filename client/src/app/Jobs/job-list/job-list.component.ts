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
import { Router } from '@angular/router';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements OnInit {
  jobs: Job [];
  user: User;
  member: Member;
  pagination: Pagination;
  postedByUser: Boolean;
  jobParams: JobsParams;

  genderList = GENDER_LIST;

  constructor(private memberService: MembersService, private jobsService: JobsService, private accountService: AccountService) {
    this.jobParams = this.jobsService.getUserParams();
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
    this.memberService.getMember(this.user.username).subscribe(member => {
      this.member = member;
    });


  }

  ngOnInit(): void {
    this.jobs = 

    [{
        id: 0,
        title: "Lisa",
        orgId: 1,
        jobPosterId: 1,
        logoUrl: "https://randomuser.me/api/portraits/women/54.jpg",
        description: "Here is the Description",
        salary:500,
        city: "Calgary",
        province: "Alberta",
        country: "Canada",
        genres: "Drummer,Guitarist,Male Singer",
        jobType: "Piano",
        skillsRequired: "Professional",
        applicationUrl: "lool",
        dateCreated: new Date(),
        deadline: new Date(),
        lastUpdated: new Date()
      }, {
        id: 0,
        title: "Pisa",
        orgId: 2,
        jobPosterId: 2,
        logoUrl: "https://randomuser.me/api/portraits/women/59.jpg",
        description: "Here is the Description",
        salary:500,
        city: "Calgary",
        province: "Alberta",
        country: "Canada",
        genres: "Drummer,Guitarist,Male Singer",
        jobType: "Piano",
        skillsRequired: "Professional",
        applicationUrl: "lool",
        dateCreated: new Date(),
        deadline: new Date(),
        lastUpdated: new Date()
      }];

    //this.loadMembers();
  }

  loadMembers() {
    this.jobsService.setUserParams(this.jobParams);

    this.jobsService.getJobs(this.jobParams).subscribe((response) => {
      this.jobs = response.result;
      this.pagination = response.pagination;
    });



  }

  btnClick()
  {

  }

  loadJobsByUserId(id: number)
  {
    this.jobsService.setUserParams(this.jobParams);
    this.jobsService.getJobsByPosterId(id, this.jobParams).subscribe((response) => {
      this.jobs = response.result;
      this.pagination = response.pagination;
    });

  }

  loadJobsByTitle(title: string)
  {
    this.jobsService.setUserParams(this.jobParams);
    this.jobsService.getJobsByTitle(title, this.jobParams).subscribe((response) => {
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
