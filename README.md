# Development Setup for Windows using WSL (Debian Image)

This document outlines the setup for a development environment on Windows using WSL (Windows Subsystem for Linux) with a Debian-based image. The following tools are installed on the Debian image:

- **Docker**
- **.NET Core 9.0.203**
- **Node.js v18.20.8**
- **npm 10.8.2**

## Prerequisites

1. **WSL 2 (Windows Subsystem for Linux)** must be installed on your Windows machine.
2. **Debian-based image**: You should have Debian installed as your Linux distribution in WSL.

### Install WSL and Debian (if not installed)

### Spin up all related servers for development
Run docker compose up -d


Part of this code is based on this article:
https://medium.com/@hasanovtural11/permission-based-authentication-and-authorization-in-net-and-vue-js-through-jwt-tokens-5cec440ecf4e


TODO:
21-4-25 use bind mound volume in mysql docker instead of named volume