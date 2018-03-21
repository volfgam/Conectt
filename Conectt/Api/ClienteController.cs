﻿using Conectt.Enum;
using Conectt.Repositories;
using Conectt.Util;
using Conectt.ViewModels;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conectt.Api
{
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        private readonly ConecttContext _context;
        private ClienteRepository _clienteRepository;

        public ClienteController(ConecttContext context)
        {
            _context = context;
        }

        [HttpPost("AdicionarCliente")]
        public async Task<JsonResult> AdicionarCliente(ClienteViewModel clienteModel)
        {
            _clienteRepository = new ClienteRepository(_context);
            var mensagens = new List<Mensagem>();
            var sucesso = true;

            //valida cpf
            clienteModel.Cpf = clienteModel.Cpf.Trim();
            clienteModel.Nome = clienteModel.Nome.Trim();
            clienteModel.Email = clienteModel.Email.Trim();
            clienteModel.Empresa = clienteModel.Empresa.Trim();
            clienteModel.TelefoneComercialDdd = clienteModel.TelefoneComercialDdd.Trim();
            clienteModel.TelefoneComercial = clienteModel.TelefoneComercial.Trim();
            clienteModel.CelularDdd = clienteModel.CelularDdd.Trim();
            clienteModel.Celular = clienteModel.Celular.Trim();

            if (String.IsNullOrEmpty(clienteModel.Nome))
            {
                mensagens.Add(new Mensagem
                {
                    Tipo = ETipoMensagem.Falha,
                    Texto = "Nome do cliente não informado, este campo é obrigatório."
                });
                sucesso = false;
            }
            if (String.IsNullOrEmpty(clienteModel.Email))
            {
                mensagens.Add(new Mensagem
                {
                    Tipo = ETipoMensagem.Falha,
                    Texto = "E-mail do cliente não informado, este campo é obrigatório."
                });
                sucesso = false;
            }

            if (!String.IsNullOrEmpty(clienteModel.Cpf))
            {
                //Valida se o CPF é um CPF válido
                if (CpfValidation.Validar(clienteModel.Cpf))
                {
                    //Verifica no banco de dados se este cpf já esta cadastrado
                    if (await _clienteRepository.CpfExistente(clienteModel.Cpf))
                    {
                        mensagens.Add(new Mensagem
                        {
                            Tipo = ETipoMensagem.Falha,
                            Texto = "Cliente já cadastrado, não é possível cadastrar novamente."
                        });
                        sucesso = false;
                    }
                } else
                {
                    mensagens.Add(new Mensagem
                    {
                        Tipo = ETipoMensagem.Falha,
                        Texto = "CPF esta em um formato inválido, por favor verifique."
                    });
                    sucesso = false;
                }
            }
            else
            {
                mensagens.Add(new Mensagem
                {
                    Tipo = ETipoMensagem.Falha,
                    Texto = "CPF não foi informado"
                });
                sucesso = false;    
            }

            //somente maiores de 18 podem ser cadastrados
            if (clienteModel.DataNascimento == null)
            {
                mensagens.Add(new Mensagem
                {
                    Tipo = ETipoMensagem.Falha,
                    Texto = "Data de nascimento não informado, este campo é obrigatório."
                });
                sucesso = false;
            } else
            {

            }
            //validar campos obrigatórios 
            //mensagem de sucesso "Formulário enviado com sucesso. Em breve entraremos em contato."

            return Json(new
            {
                Sucesso = sucesso,
                Mensagens = mensagens
            });
        }
    }

    public class Mensagem
    {
        public ETipoMensagem Tipo { get; set; }
        public string Texto { get; set; }
    }
}
