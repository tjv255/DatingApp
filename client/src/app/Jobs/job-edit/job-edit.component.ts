
import { datepickerAnimation } from 'ngx-bootstrap/datepicker/datepicker-animations';
import { Job } from 'src/app/_models/job';

import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { JobsService } from 'src/app/_services/jobs.service';
import { MembersService } from 'src/app/_services/members.service';
import { take } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { AccountService } from 'src/app/_services/account.service';
import { JobsParams } from 'src/app/_models/jobParams';
import { Pagination } from 'src/app/_models/pagination';

@Component({
  selector: 'app-job-edit',
  templateUrl: './job-edit.component.html',
  styleUrls: ['./job-edit.component.css']
})

export class JobEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  job: Job = null;
  member: Member;
  user: User;
  jobParams: JobsParams;
  jobs: Job [];
  pagination: Pagination;
  //id: number;
  
  
  constructor(private memberService: MembersService, private jobService: JobsService,private accountService : AccountService
    ,private toastr: ToastrService ) { 
      this.jobParams = this.jobService.getUserParams();
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      console.log(this.user);
      this.memberService.getMember(this.user.username).subscribe((m) => {
        this.loadJobsByUserId(m.id);
        this.loadJobsFromCard(this.job.id);
        this.member = m;
      });
     

      jobService.getJob(12).subscribe(job => {
        this.job = job;
      });

      // this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      // this.memberService.getMember(this.user.username).subscribe(member => {
      //   this.member = member;
      
    }

  ngOnInit(): void {

    //this.loadJobsFromCard(this.job.id);

    /*
    this.job = {
      id: 10,
      title: "Hello",
      orgId: 12,
      jobPosterId: 1,
      jobPosterName: "lisa",
      logoUrl: "https://randomuser.me/api/portraits/men/93.jpg",
      description: "Need farm work who can feed cows",
      salary: 20000,
      city: "Pizza Land",
      provinceOrState: "Vegas",
      country: "Italy1",
      genres: "Strong, Talented",
      jobType: "Hard",
      skillsRequired: "Farming, Mooing, Grass eating",
      applicationUrl: "https://randomuser.me/api/portraits/men/93.jpg",
      dateCreated: new Date(Date.now()),
      deadline: new Date('2022-09-29'),
      lastUpdated: new Date(Date.now())
    }
    
    */

      
  }

  UpdateJob(){
    console.log(this.job);
    this.jobService.updateJob(this.job).subscribe(() =>{
      this.toastr.success('Profile updated');
      this.editForm.reset(this.job);
    })
  }

  
  loadJobsByUserId(id: number)
  {
    console.log("HII");
    console.log(id);
    this.jobService.setUserParams(this.jobParams);
    this.jobService.getJobsByPosterId(id, this.jobParams).subscribe((response) => {
      console.log(response);
      console.log(response.result);
      this.jobs = response.result;
      this.pagination = response.pagination;
    });
  }

  loadJobsFromCard(id: number)
  {
    this.jobs.forEach(function (value) {
      console.log(value);
    });
  }

  //loadJob() {
   // this.jobService.getJob.().subscribe(job => {
     // this.job = job;
    //})
  //}

  //
// GetJob(id: number){
//   this.jobService.getJob(id).subscribe(job => {
//     this.job = job
//   });
// }
 
  //UpdateJob(data: any)
  //{

   // console.warn(data)

   // this.jobService.getJobs(data).subscribe((data) =>{
   //   this.job = data;
   // })
  //}

  /*
  UpdateJob() {
    this.jobService.updateJob(this.job).subscribe(() => {
      this.toastr.success('Job Updated successfully');
      this.editForm.reset(this.job);
    })
  }
  */
  /*DeleteJob(jobid: number) {
    this.jobService.deleteJob(jobid).subscribe(() => {
      this.toastr.success('Job Deleted successfully');
    })
  }*/
}
