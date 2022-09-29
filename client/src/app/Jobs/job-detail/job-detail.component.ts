import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from '@kolkov/ngx-gallery';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { Message } from 'src/app/_models/message';
import { MessageService } from 'src/app/_services/message.service';
import { PresenceService } from 'src/app/_services/presence.service';
import { AccountService } from 'src/app/_services/account.service';
import { User } from 'src/app/_models/user';
import { take } from 'rxjs/operators';
import { Job } from 'src/app/_models/job';
import { Organization } from 'src/app/_models/organization';
import { MembersService } from 'src/app/_services/members.service';
import { OrganizationsService } from 'src/app/_services/organizations.service';

@Component({
  selector: 'app-job-detail',
  templateUrl: './job-detail.component.html',
  styleUrls: ['./job-detail.component.css']
})
export class JobDetailComponent implements OnInit {
  @ViewChild('jobTabs', {static: true}) jobTabs: TabsetComponent;
  job: Job;
  orgs: Organization[];
  member: Member;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  activeTab: TabDirective;

  constructor(private route: ActivatedRoute, private memberService: MembersService, private organizationsService: OrganizationsService, private router: Router ) { 
  //Load member and load Organization objects from server 
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;

  }

  ngOnInit(): void {

    /*this.memberService.getMemberbyId(this.job.jobPosterId).subscribe((response) => {
      this.member = response;
    });*/

    /*this.organizationService.getMemberbyId(this.job.jobPosterId).subscribe((response) => {
      this.orgs = response;
    }); 
    */
  }



}
