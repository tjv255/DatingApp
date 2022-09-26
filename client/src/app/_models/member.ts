import { Photo } from "./photo"

export interface Member {
  id: number
  username: string
//   photoUrl: string
//   age: number
//   knownAs: string
//   created: Date
//   lastActive: Date
//   gender: string
  introduction: string // keep this?
  lookingFor: string // change required
  interests: string // change required
//   city: string
//   country: string
//   photos: Photo[]   
    firstName: string;
    lastName: string;
    knownAs: string;
    email: string;
    gender: string; 
    age: string;
    city: string;
    province: string;  
    country: string; 
    occupation: string;
    skills: string[];
    genres: string[];
    affiliation: string;
    created: Date;
    lastActive: Date;    
    photoUrl: string; 
    photos: Photo[];
    
}


