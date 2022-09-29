
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
  
  constructor(private jobService: JobsService, private memberService: MembersService,
    private toastr: ToastrService) { 
      
    }

  ngOnInit(): void {
    
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
      country: "Italy",
      genres: "Strong, Talented",
      jobType: "Hard",
      skillsRequired: "Farming, Mooing, Grass eating",
      applicationUrl: "https://randomuser.me/api/portraits/men/93.jpg",
      dateCreated: new Date(Date.now()),
      deadline: new Date(Date.now()),
      lastUpdated: new Date(Date.now())
    }

      
  }
 /* UpdateJob(Job: job)
  {
    this.jobService.updateJob(job, id);
  }
  */
  UpdateJob() {
    this.jobService.updateJob(this.job).subscribe(() => {
      this.toastr.success('Job Updated successfully');
      this.editForm.reset(this.job);
    })
  }

  /*DeleteJob(jobid: number) {
    this.jobService.deleteJob(jobid).subscribe(() => {
      this.toastr.success('Job Deleted successfully');
    })
  }*/
}
