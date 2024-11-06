﻿using ExpenseTracker.Domain;
using ExpenseTracker.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Requests.Commands.UserCommands
{
        public class AddUserCommandHandler(IUserRepository userRepository) : IRequestHandler<AddUserCommand, int>
        {
            private readonly IUserRepository userRepository = userRepository;

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                User user = new User();
                user.Name = request.Name;
                user.PhoneNumber = request.PhoneNumber;
                user.Password = request.Password;

                int result = userRepository.AddUser(user);
                return await Task.FromResult(result);
            }
        }
}