# Define the name of your executable
TARGET = ConsoleAppforFindReplace

# Define the source files
SOURCES = $(wildcard *.cs)  # Adjust this if your .cs files are in subdirectories

# Define the output directory (optional)
OUTPUT_DIR = bin

# Default target
all: build run

# Run target
run: build
	dotnet ConsoleAppforFindReplace.dll

# Clean target
clean:
	dotnet clean
	rm -rf $(OUTPUT_DIR)

# Phony targets
.PHONY: all build run clean
