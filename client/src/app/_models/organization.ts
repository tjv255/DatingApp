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
    created: Date
    lastUpdated: Date
    //Maybe implement in next sprint
    //jobs: Job[]
    //backend returns memebers who liked the org

    photos: Photo[]
    members: Member[]
}