import { DimensionModel } from "./dimension.model";
import { RickModel } from "./rick.model";

export class MortyModel {
    id: number;
    image: string;
    name: string;
    age: number;
    occupation: string;
    rick: RickModel;
    dimension: DimensionModel;
}