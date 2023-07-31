
# vstup-statistic

Data was downloaded from this site: https://vstup.edbo.gov.ua/statistics/global-order/

Url for getting specific excel document - https://registry.edbo.gov.ua/files/go/25.07.2023/B01d.xlsx 

Exmaple of parsed data:
```json
[{
        "AverageGrade": 198.104,
        "FullName": "Муся А. І.",
        "GradeDetails": "Математика - 187.000 - Коеф.:0.400 - Бал200: ні;\nУкраїнська мова (Українська мова і література) - 182.000 - Коеф.:0.350 - Бал200: ні;\nФізика - 193.000 - Коеф.:0.250 - Бал200: ні\nРК: 1.04; ГК: 1.02",
        "Institution": "Державний заклад «Південноукраїнський національний педагогічний університет імені К.Д. Ушинського»",
        "Priority": 1,
        "Quota": "",
        "RankNumber": 1,
        "RequiresInterview": false,
        "generalStats": {
            "DegreeType": "Бакалавр",
            "LoadTime": "25.07.2023 16:59",
            "Specialities": ["012 Дошкільна освіта", "013 Початкова освіта"],
            "StateOrderVolume": 2150,
            "StudyFormat": "Денна"
        }
    },
    ...
]
```
