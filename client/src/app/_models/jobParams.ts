import { User } from "./user";

export class JobsParams {
  jobType: string;
  pageNumber = 1;
  pageSize = 5;
  genres?: string;
  skillsRequired?: string;
  city?: string;
  provinceOrState?: string;
  country?: string;
  orderBy = 'mostRecent'; 
  // --> Other sortig options:
  // -- "alphabetical" - ascending
  // -- "deadline" - desc.
  // -- "lastUpdated" - desc.

  // No need for the constructor
  constructor() {

  }
}