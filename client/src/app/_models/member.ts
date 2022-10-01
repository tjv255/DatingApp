import { Job } from "./job";
import { Organization } from "./organization";
import { Photo } from "./photo"

export interface Member {
    id: number;
    username: string; // changes required to remove
    photoUrl: string;
    age: number;
    knownAs: string;
    created: Date;
    lastActive: Date;
    gender: string;
    introduction: string; // changes required to remove
    lookingFor: string; // changes required to remove
    interests: string; // changes required to remove
    city: string;
    country: string;
    photos: Photo[];
    createdJobs: Job[];
    affiliation: Organization[];

    /*firstName: string;
    lastName: string;

    email: string;

   

    provinceOrState: string;

    occupation: string;
    skills: string[];
    genres: string[];*/

   
    
    

}


