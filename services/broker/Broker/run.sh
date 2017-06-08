#!/bin/bash
set -e

cd ./Broker

dotnet ef database update

dotnet run
