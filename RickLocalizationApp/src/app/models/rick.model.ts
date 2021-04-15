import { DimensionModel } from "./dimension.model";
import { MortyModel } from "./morty.model";
import { RickDimension } from "./rick-dimension.model";

export class RickModel {
    id: number;
    species: string;
    image: string;
    name: string;
    age: number;
    occupation: string;
    morty: MortyModel;
    dimension: DimensionModel;
    // travels: RickDimension[];
  rickDimensions: RickDimension[];
}