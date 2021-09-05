import { TemplateWeek } from './../models/template-week.model';

const json =
{
  "id": 1,
  "active": true,
  "trainings": [
    {
      "id": 1,
      "dayOfWeek": 3,
      "startHour": "0001-01-01T17:30:00",
      "endHour": "0001-01-01T18:30:00",
      "group": 0,
      "trainers": [
        {
          "name": "Hanne"
        },
        {
          "name": "Jorinde"
        }
      ],
      "registrations": []
    },
    {
      "id": 2,
      "dayOfWeek": 3,
      "startHour": "0001-01-01T17:30:00",
      "endHour": "0001-01-01T18:30:00",
      "group": 1,
      "trainers": [
        {
          "name": "Helen"
        },
        {
          "name": "Jeroen"
        }
      ],
      "registrations": []
    },
    {
      "id": 3,
      "dayOfWeek": 3,
      "startHour": "0001-01-01T19:30:00",
      "endHour": "0001-01-01T21:00:00",
      "group": 3,
      "trainers": [
        {
          "name": "Hans"
        }
      ],
      "registrations": []
    },
    {
      "id": 4,
      "dayOfWeek": 3,
      "startHour": "0001-01-01T19:30:00",
      "endHour": "0001-01-01T21:00:00",
      "group": 4,
      "trainers": [
        {
          "name": "Marthe"
        }
      ],
      "registrations": []
    },
    {
      "id": 5,
      "dayOfWeek": 0,
      "startHour": "0001-01-01T10:30:00",
      "endHour": "0001-01-01T11:30:00",
      "group": 3,
      "trainers": [
        {
          "name": "Lies"
        },
        {
          "name": "Michiel"
        }
      ],
      "registrations": []
    },
    {
      "id": 6,
      "dayOfWeek": 5,
      "startHour": "0001-01-01T18:00:00",
      "endHour": "0001-01-01T19:00:00",
      "group": 4,
      "trainers": [
        {
          "name": "Helen"
        },
        {
          "name": "Marthe"
        }
      ],
      "registrations": []
    },
    {
      "id": 7,
      "dayOfWeek": 5,
      "startHour": "0001-01-01T18:00:00",
      "endHour": "0001-01-01T19:00:00",
      "group": 5,
      "trainers": [
        {
          "name": "Piet"
        }
      ],
      "registrations": []
    },
    {
      "id": 8,
      "dayOfWeek": 0,
      "startHour": "0001-01-01T10:30:00",
      "endHour": "0001-01-01T11:30:00",
      "group": 9,
      "trainers": [
        {
          "name": "Kris"
        }
      ],
      "registrations": []
    },
    {
      "id": 9,
      "dayOfWeek": 5,
      "startHour": "0001-01-01T18:00:00",
      "endHour": "0001-01-01T19:00:00",
      "group": 2,
      "trainers": [
        {
          "name": "Colette"
        },
        {
          "name": "Jente"
        }
      ],
      "registrations": []
    },
    {
      "id": 10,
      "dayOfWeek": 2,
      "startHour": "0001-01-01T19:30:00",
      "endHour": "0001-01-01T21:00:00",
      "group": 9,
      "trainers": [
        {
          "name": "Kris"
        }
      ],
      "registrations": []
    }
  ]
}

export const TEMPLATE_WEEK: TemplateWeek = TemplateWeek.fromJSON(json);
