export interface Gender {
    value: string;
    display: string;
}

export interface MultiselectSelectionItem {
    item_id: number;
    item_text: string;
}

export const GENDER_LIST: MultiselectSelectionItem[] = [
    {
        item_id: 1,
        item_text: 'Male',
    },
    {
        item_id: 2,
        item_text: 'Female',
    },
    {
        item_id: 3,
        item_text: 'Non-Binary',
    },
    {
        item_id: 4,
        item_text: 'Unidentified',
    },
    {
        item_id: 5,
        item_text: 'Other',
    },
];

export const SKILL_LIST: MultiselectSelectionItem[] = [
    {
        item_id: 1,
        item_text: 'Skill A',
    },
    {
        item_id: 2,
        item_text: 'Skill B',
    },
    {
        item_id: 3,
        item_text: 'Skill C',
    },
    {
        item_id: 4,
        item_text: 'Skill D',
    },
    {
        item_id: 5,
        item_text: 'Skill E',
    },
];

export const GENRE_LIST: MultiselectSelectionItem[] = [
    {
        item_id: 1,
        item_text: 'Genre A',
    },
    {
        item_id: 2,
        item_text: 'Genre B',
    },
    {
        item_id: 3,
        item_text: 'Genre C',
    },
    {
        item_id: 4,
        item_text: 'Genre D',
    },
    {
        item_id: 5,
        item_text: 'Genre E',
    },
];

export const ORG_TYPE: MultiselectSelectionItem[] = [
  {
    item_id: 1,
    item_text: 'Entertainment Companies',
  },
  {
    item_id: 2,
    item_text: 'Performing Groups',
  },
  {
    item_id: 3,
    item_text: 'Theatres and Opera Houses',
  },
  {
    item_id: 4,
    item_text: 'Bands',
  },
  {
    item_id: 5,
    item_text: 'Concert Bands',
  },
  {
    item_id: 6,
    item_text: 'Musical Ensembles',
  },
  {
    item_id: 7,
    item_text: 'Symphony Orchestra',
  },
  {
    item_id: 8,
    item_text: 'Choirs',
  },
  {
    item_id: 9,
    item_text: 'Music Academies',
  },
  {
    item_id: 10,
    item_text: 'Educational Institutions',
  },
  {
    item_id: 11,
    item_text: 'Talent Agencies',
  },
  {
    item_id: 12,
    item_text: 'Others',
  },
];

// Mock Org data. Real data will reflect OrganizationDto.cs
export const AFFILIATION_DATA = [
  {
    id: 1,
    name: 'Spring Reed',
    introduction: 'Lorem ipsum dolor sit amet',
    established: 2008,
    photoUrl: 'https://randomuser.me/api/portraits/women/54.jpg',
  },
  {
    id: 2,
    name: 'Summer Salt',
    introduction: 'Lorem ipsum dolor sit amet',
    established: 2004,
    photoUrl: 'https://randomuser.me/api/portraits/women/54.jpg'
  },
  {
    id: 3,
    name: 'Winterizers',
    introduction: 'Lorem ipsum dolor sit amet',
    established: 2012,
    photoUrl: 'https://randomuser.me/api/portraits/women/54.jpg'
  },
];

export const JOB_TYPE: MultiselectSelectionItem[] = [
    {
        item_id: 0,
        item_text: '',
    },
    {
        item_id: 1,
        item_text: 'One-time gig',
    },
    {
        item_id: 2,
        item_text: 'Multi-day gig',
    },
    {
        item_id: 3,
        item_text: 'Part-time',
    },
    {
        item_id: 4,
        item_text: 'Full-time',
    },
    {
        item_id: 5,
        item_text: 'Contract',
    },
    {
        item_id: 5,
        item_text: 'Volunteer',
    }
];

export const JOB_SORT_ORDER: MultiselectSelectionItem[] = [
    {
        item_id: 1,
        item_text: 'dateCreated',
    },
    {
        item_id: 2,
        item_text: 'alphabetical',
    },
    {
        item_id: 3,
        item_text: 'deadline',
    },
    {
        item_id: 4,
        item_text: 'lastUpdated',
    }
];

  export const AFFILIATION_LIST: MultiselectSelectionItem[] = AFFILIATION_DATA.map( org => ({item_id: org.id, item_text: org.name}));