export interface FormData {
  submitterName: string;
  createdAt: Date;
  sectorNames: string[];
}

export interface State {
  forms: FormData[];
}