# TramPlanner

## Overview
TramPlanner is a Blazor WebAssembly application with an ASP.NET Core Web API backend. 
The application allows users to see visualization of trams waiting in the depot and plan missions for trams in a depot.

Application is intended just for demo purposes to be run in DEV environment.

## Project Structure

- `TramPlannerRestApi`: ASP.NET Core Web API project serves as server simulation
- `TramPlannerFrontEnd`: Blazor WebAssembly project shows simple depot visualization and allows mission planning.
- `TramPlannerLib`: Shared library containing models and services.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Getting Started

### Running the API

1. Open a terminal and navigate to the `TramPlannerRestApi` project directory:
cd path/to/TramPlannerRestApi

2. Run the API:
dotnet run --launch-profile http

3. Api will be listening on `http://localhost:5197` (or the URL specified in the terminal).

### Running the Blazor WebAssembly Client

1. Open a terminal and navigate to the `TramPlannerFrontEnd` project directory:
cd path/to/TramPlannerFrontEnd

2. Run the Blazor WebAssembly client:
dotnet run

3. Open your web browser and navigate to `http://localhost:5092` (or the URL specified in the terminal).

## Troubleshooting

## CORS Configuration

The API is configured to allow requests from the Blazor WebAssembly client. Ensure the URL in the CORS policy matches the URL where your Blazor client is running.

### CORS Issues

If you encounter CORS issues, ensure the CORS policy in `Program.cs` of the `TramPlannerRestApi` project is correctly configured:
    