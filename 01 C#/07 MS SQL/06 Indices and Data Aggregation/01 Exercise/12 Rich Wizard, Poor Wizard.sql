SELECT SUM(h.DepositAmount - g.DepositAmount)
  FROM WizzardDeposits AS h
  JOIN WizzardDeposits AS g ON h.Id = g.Id - 1