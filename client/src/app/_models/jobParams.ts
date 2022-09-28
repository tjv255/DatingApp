import { User } from "./user";

export class JobsParams {
  jobType: string;
  pageNumber = 1;
  pageSize = 5;
  orderBy = 'mostRecent';

  constructor() {

  }
}