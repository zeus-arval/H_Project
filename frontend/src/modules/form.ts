export interface FormData {
  submitterName: string;
  createdAt: Date;
  SectorNames: string[];
}

export interface State {
  forms: FormData[];
}