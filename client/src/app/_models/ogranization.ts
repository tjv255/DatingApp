import { Job } from "./job"
import { Member } from "./member"
import { Photo } from "./photo"

export interface Ogranization {
    id: number
    name: string
    introduction: string
    established: Date
    created: Date
    lastUpdated: Date
    //backend returns list of members who work for the org
    members: Member[]
    jobs: Job[]
    //backend returns memebers who liked the org
    memberswholiked: Member []
    photos: Photo[]
}