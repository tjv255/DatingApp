import { Job } from "./job"
import { Member } from "./member"
import { Photo } from "./photo"

export interface Organization {
    id: number
    //orgOwnerId: number
    name: string
    introduction: string
    photoUrl: string
    established: number
    city: string
    provinceOrState: string
    country: string
    photos: Photo[]
    // created: Date
    // lastUpdated: Date

    //Maybe implement in next sprint
    //jobs: Job[]
    //backend returns memebers who liked the org

    // photos: Photo[]
    // members: Member[]

    /***
     *   
    "name": "test org 1",
    "introduction": "Lorem ipsum",
    "established": 2010,
    "city": "Paris",
    "provinceOrState": "Paris",
    "country": "France",
    "photos": null
     */
}