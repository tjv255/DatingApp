import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { FileUploader } from 'ng2-file-upload';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { Organization } from 'src/app/_models/organization';
import { Pagination } from 'src/app/_models/pagination';
import { UserParams } from 'src/app/_models/userParams';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-organization-detail',
  templateUrl: './organization-detail.component.html',
  styleUrls: ['./organization-detail.component.css']
})
export class OrganizationDetailComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  uploader: FileUploader;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  members: Member[];
  pagination: Pagination;
  userParams: UserParams;

  organization: any;

  constructor(private memberService: MembersService, private toastr: ToastrService) {
    this.userParams = this.memberService.getUserParams();
   }

  ngOnInit(): void {
    this.loadOrganization();
    this.loadMembers();

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ];
    
    this.galleryImages = this.getImages();

  }

  loadOrganization(){
    this.organization = {
      knownAs: "Test Job Title",
      introduction: "test intro",
      interests: "test interests",
      lookingFor: "test looking for",
      city: "test city",
      country: "test country",
      name: "Test organization Name",
      likes: 10,
      members: [
        {

        },
        {

        },{},{}
      ],
      established: "2015",
      about: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
      
    };
  }

  updateOrganization(){
    console.log("Update clicked");
  }

  getImages(){
    var images = [];
    images.push({
      small: 'https://i.picsum.photos/id/988/200/200.jpg?hmac=-lwK-i6PssD9WlUeVPDIhOxDVxlzJKeM4MgEx_fIqJg',
      medium: 'https://i.picsum.photos/id/988/200/200.jpg?hmac=-lwK-i6PssD9WlUeVPDIhOxDVxlzJKeM4MgEx_fIqJg',
      big: 'https://i.picsum.photos/id/988/200/200.jpg?hmac=-lwK-i6PssD9WlUeVPDIhOxDVxlzJKeM4MgEx_fIqJg'
    });

    images.push({
      small: 'https://i.picsum.photos/id/367/200/200.jpg?hmac=6NmiWxiENMBIeAXEfu9fN20uigiBudgYzqHfz-eXZYk',
      medium: 'https://i.picsum.photos/id/367/200/200.jpg?hmac=6NmiWxiENMBIeAXEfu9fN20uigiBudgYzqHfz-eXZYk',
      big: 'https://i.picsum.photos/id/367/200/200.jpg?hmac=6NmiWxiENMBIeAXEfu9fN20uigiBudgYzqHfz-eXZYk'
    });

    images.push({
      small: 'https://i.picsum.photos/id/214/200/200.jpg?hmac=hcznBngs7e7PmNwXcM4UioAhb1oOUpfGDzBM-qSgpp4',
      medium: 'https://i.picsum.photos/id/214/200/200.jpg?hmac=hcznBngs7e7PmNwXcM4UioAhb1oOUpfGDzBM-qSgpp4',
      big: 'https://i.picsum.photos/id/214/200/200.jpg?hmac=hcznBngs7e7PmNwXcM4UioAhb1oOUpfGDzBM-qSgpp4'
    });

    return images;
  }

  loadMembers() {
    this.memberService.setUserParams(this.userParams);
    this.memberService.getMembers(this.userParams).subscribe((response) => {
      this.members = response.result;
      this.pagination = response.pagination;
    });
  }

  addLike(organization: Organization) {
    this.toastr.success('You have liked ');
    //add addLike method in organization service
    // this.memberService.addLike(member.username).subscribe(() => {
    //   this.toastr.success('You have liked ' + member.knownAs);
    // })
  }

}
