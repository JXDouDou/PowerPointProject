# PowerPoint-Style Drawing App (C#)

A Windows desktop app for drawing and editing shapes, inspired by PowerPoint. Built in C# with Windows Forms for a software design course at National Taipei University of Technology (Fall 2023).

## Features

- Draw lines, rectangles and circles from the toolbar
- Select, move and delete shapes
- Undo and redo

## Design

| Pattern | Where it is used |
| --- | --- |
| Presentation Model | Separates the form (UI) from the drawing logic, so the logic can be unit-tested without the UI |
| State | Switches between drawing mode and selection mode |
| Command | Each edit is a command object, which enables undo/redo |
| Factory | Creates shape objects by type |

**Testing:** 123 unit tests with MSTest (`PowerPointProjectTests/`). Code was checked with a static code review tool and the reported issues ("bad smells") were fixed.

## Build and run

Requirements: Windows, Visual Studio 2019 or later with the ".NET desktop development" workload, and .NET Framework 4.7.2.

1. Open `PowerPointProject.sln` in Visual Studio.
2. Set `WindowsProject` as the startup project.
3. Press **F5** to build and run.
4. To run the tests: **Test > Run All Tests** (Test Explorer).

## Project structure

```
WindowsProject/
  Model/                  shapes, states, commands and the factory
  View/                   forms and the presentation model
PowerPointProjectTests/   unit tests
```
