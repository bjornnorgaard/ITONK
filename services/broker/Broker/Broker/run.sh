#!/bin/bash
set -e

dotnet ef database update

dotnet run
