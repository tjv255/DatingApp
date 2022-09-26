import { Photo } from "./photo"
import { User } from "./user"

export interface Job {
    id: number
    title: string
    //Ogranization which posted this job
    //dependant on cap72
    orgId: number
    jobPoster: User
    photos: Photo[]
    description: string
    salary: number
    city: string
    province: string
    country: string
    genres: string
    jobType: string
    skillsRequired: string
    applicationUrl: string
    dateCreated: Date
    deadline: Date
    lastUpdated: Date




  }