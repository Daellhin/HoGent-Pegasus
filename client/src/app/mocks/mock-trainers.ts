import { Trainer } from "../models/trainer.model";

const json =
[
  {
    "name": "Colette"
  },
  {
    "name": "Hanne"
  },
  {
    "name": "Hans"
  },
  {
    "name": "Helen"
  },
  {
    "name": "Jente"
  },
  {
    "name": "Jeroen"
  },
  {
    "name": "Jorinde"
  },
  {
    "name": "Kris"
  },
  {
    "name": "Lies"
  },
  {
    "name": "Marthe"
  },
  {
    "name": "Michiel"
  },
  {
    "name": "Piet"
  }
];

export const TRAINERS: Trainer[] = json.map(Trainer.fromJSON);
